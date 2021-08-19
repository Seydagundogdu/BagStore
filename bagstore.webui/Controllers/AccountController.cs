using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using bagstore.webui.Identity;
using bagstore.webui.Models;
using System.Threading.Tasks;
using bagstore.business.Abstract;

namespace bagstore.webui.Controllers
{
    public class AccountController: Controller
    {
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private ICartService _cartService;
        public AccountController(UserManager<User> userManager,SignInManager<User> signInManager,ICartService cartService)//inject
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cartService = cartService;
        }

        [HttpGet] 
        public IActionResult Login(string returnUrl=null) //login olduktan sonra son ziyaret edilen sayfaya dönmek için returnurl
        {
           return View(new LoginModel()
           {
               ReturnUrl = returnUrl
           });
        } 

        [HttpPost]
        [ValidateAntiForgeryToken] //csrf ataklarını engellemek için
        public async Task<IActionResult> Login(LoginModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            // var user =await _userManager.FindByNameAsync(model.UserName);
            var user =await _userManager.FindByEmailAsync(model.Email);

            if(user==null)
                {
                    ModelState.AddModelError("","Kullanıcı bulunamadı.");
                    return View(model);
                }

                var result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);  //kullanıcıya bir cookie bırakmak istiyorum o yüzden signInManager
                //persistent (3. parametre) true verilirse bu kullanıcı tarayıcıyı kapatıldıktan belli bir süre geçtikten sonra (365gün) cookie silinecek ve kullanıcı logout olacak demektir
                //4. parametre: şifre yanlış girildiğinde hesap kapatma işlemi, false
        
            if(result.Succeeded)
            {
                return Redirect(model.ReturnUrl??"~/");//returnUrl yoksa anasayfaya git
            }

            ModelState.AddModelError("","Kullanıcı adı veya parola yanlış.");
        
            return View(model);
        } 

        [HttpGet]
        public IActionResult Register()
        {
           return View();
        } 
        [HttpPost]
        [ValidateAntiForgeryToken] //get ile gönderilen token bilgisi posta gelmiyorsa hata döndürür
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var user = new User()//parola hashleneceği için onun ataması yapılmaz
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                UserName = model.UserName,
                Email = model.Email
            };

            var result = await _userManager.CreateAsync(user,model.Password);
            if(result.Succeeded) //kullanıcı oluşturma işlemi başarılıysa
            {   
                _cartService.InitializeCart(user.Id);// cart kaydı oluşturulur
                
                // await userManager.AddToRoleAsync(user,"Customer");
                return RedirectToAction("Login","Account");
            }

            ModelState.AddModelError("Password","Parola belirlenen kriterlere uygun değil");
            return View(model);
        } 

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();//cookieyi tarayıcıan siler
            return Redirect("~/");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}