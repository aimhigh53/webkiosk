using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using cSharpPro.Models;
using System.Collections;
using System.Diagnostics;
using cSharpPro.Datacontext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
namespace cSharpPro.Controllers
{
    public class KioskController : Controller
    {
        //버거의 버튼을 눌렀을때 들어오는 배열
        ArrayList Lpicked = new ArrayList();
        ArrayList Lprice = new ArrayList();
        ArrayList Lcount = new ArrayList(); // DH0611
        string first = "싸이버거";
        string second = "디럭스 불고기 버거";
        string third = "통새우버거";
        // GET: /<controller>/
        public IActionResult Index()
        {
            Bag.Rpicked = "";
            Bag.Rprice = "";
            return View();
        }
        public IActionResult TakeOut()
        {
            ViewData["first"] = first;
            ViewData["second"] = second;
            ViewData["third"] = third;

            ViewData["src1"] = Change(first) + ".jpg";
            ViewData["src2"] = Change(second) + ".jpg";
            ViewData["src3"] = Change(third) + ".jpg";

            return View();
        }
        public IActionResult SideMenu()
        {
            return View();
        }
        public IActionResult Barcode()
        {
            return View();
        }
        public IActionResult Menu_beverage()
        {

            Debug.WriteLine("Menu_beverage : " + Bag.Rpicked);
            Debug.WriteLine("Menu_beverage : " + Bag.Rprice);
            return View();
        }
        public IActionResult Menu_Hambuger1(string name, string price, string count)
        {
            Debug.WriteLine("Menu_Hambuger1 : " + Bag.Rpicked);
            Debug.WriteLine("Menu_Hambuger1 : " + Bag.Rprice);
            return View();
        }
        public IActionResult Menu_Hambuger2()
        {
            return View();
        }
        public IActionResult Menu_Hambuger3()
        {
            return View();
        }
        public IActionResult Menu_Hambuger_Chicken1()
        {
            Debug.WriteLine("Menu_Hambuger_Chicken1 : " + Bag.Rpicked);
            Debug.WriteLine("Menu_Hambuger_Chicken1 : " + Bag.Rprice);
            return View();
        }
        public IActionResult Menu_Hambuger_Chicken2()
        {
            return View();
        }
        public IActionResult Menu_Hambuger_ETC()
        {
            return View();
        }
        public IActionResult Menu_Hambuger_bulgogi()
        {
            return View();
        }

        public IActionResult Receipt()
        {
            
            //if (ModelState.IsValid)
            //{
            //    using (var db = new KioskDbcontext())
            //    {
            //        db.bagdbs.Add(bagdb);
            //        db.SaveChanges();
            //    }
            //    return RedirectToAction("Index", "Kiosk");
            //}

            return View();

        }
      

     
        public IActionResult Wait_Number()
        {
            Bag.count++;
            return View();
        }
        //table에 들어갈 값을 받아온다 
        [HttpPost]
        public ActionResult listInput(string Plist,string picked,int price)
        {
            var Slist = "";

            Lpicked.Add(picked);
            Lprice.Add(price);
            //picked += picked;
            //price += price;
            
            
            Console.WriteLine(picked);
            Console.WriteLine(price);
            Slist = Plist;
           // buttonArray = Plist.To
            Console.WriteLine(Slist);
            
            return Json("success");
        }
        [HttpPost]
        public ActionResult itemInput(string[] picked,int[] price)
        {
            Bag.Rpicked = "";
            Bag.Rprice = "";

            for (int i = 0; i < picked.Length; i++)
            {
                Bag.Rpicked += picked[i]+",";
                Bag.Rprice += price[i]+",";
            }

            Debug.WriteLine("input : " + Bag.Rpicked);
            Debug.WriteLine("input : " + Bag.Rprice);

            Console.WriteLine(Bag.Rpicked);
            Console.WriteLine(Bag.Rprice);
            return Json(Lcount);
            // Rpicked와 Rprice를 우선 때마다 null로 초기화하고
            // 해당 값을 한번에 다 넣는다
            // 이게 가능하게 된 이유는
            // 장바구니의 내용을 모두 view에서 다루기 때문
            // 들어간 데이터를 infoArray에 넣고
            // 추가한 데이터를 infoArray에 추가한다.
            // 이 값을 picked와 price로 보내므로
            // 모든 값은 모델에 갱신된다.
        }
        [HttpPost]
        public ActionResult itemOut(string menu, string price)
        {
            string[] menus = Bag.Rpicked.Split(',');
            string[] prices = Bag.Rprice.Split(',');

            for(int i = 0; i < menus.Length; i++)
            {
                if(menus[i] == menu)
                {
                    for (int j = i+1; j < menus.Length; j++)
                    {
                        menus[j-1] = menus[j];
                        prices[j-1] = prices[j];
                    }
                    menus[menus.Length - 1] = null;
                    prices[menus.Length - 1] = null;
                    break;
                    // 뭔가 불길
                }
            }
            Bag.Rpicked = "";
            Bag.Rprice = "";
            for (int i = 0; menus[i] != ""; i++)
            {
                Debug.WriteLine("menus [" + i + "] : " + menus[i] );

                Bag.Rpicked += menus[i] + ",";
                Bag.Rprice += prices[i] + ",";

                Debug.WriteLine(Bag.Rpicked);
            }

            //만약 장바구니에서 삭제하기가 눌리면
            //view에서만 변할게 아니라
            //model값에서 다 갈아엎어줘야한다
            //이를 위해 일단 모두 하나의 string으로 바꿔준후
            //해당 값 하나만 없애기위해 하나만 지우고 string배열을 모두 한칸씩 당겨준다
            //그리고 다시 하나의 string으로 만들어서 보관~
            // ps 신기한게 menus[i] == null이면 인식이 안되는데 ""는 인식한다?
            // ps null로 만든게 첫번쨰 for-if-for문에서인데 null이 아니라 ""으로 인식함.
                return Json(Lcount);
        }
        [HttpPost]
        public ActionResult totalOut(string menu)
        {
            string[] menus = Bag.Rpicked.Split(',');
            string[] prices = Bag.Rprice.Split(',');

            string newMenu = "";
            string newPrice = "";

            for (int i = 0; i < menus.Length; i++)
            {
                if (menus[i] != menu && menus[i] != "")
                {/*
                    Debug.WriteLine("Menu : " + Bag.Rpicked);
                    for (int j = i + 1; j < menus.Length; j++)
                    {
                        Debug.WriteLine(j);
                        menus[j - 1] = menus[j];
                        prices[j - 1] = prices[j];
                    }
                    menus[menus.Length - 1] = null;
                    prices[menus.Length - 1] = null;*/
                    //menus[i] == menu일떄 위과정
                    newMenu += menus[i] + ",";
                    newPrice += prices[i] + ",";

                }
            }
            Debug.WriteLine("menus : " + menus);
            Bag.Rpicked = "";
            Bag.Rprice = "";
            for (int i = 0; menus[i] != ""; i++)
            {
                Debug.WriteLine("menus [" + i + "] : " + menus[i]);

                Bag.Rpicked = newMenu;
                Bag.Rprice = newPrice;

                Debug.WriteLine("picked [" + i + "] : "  + Bag.Rpicked);
            }
            return Json(Lcount);
        }

        [HttpPost]
        public ActionResult sendDB()
        {
            string[] pickedDB = Bag.Rpicked.Split(',');
            string[] priceDB = Bag.Rprice.Split(',');

            bagsDB bagdb=new bagsDB();
            Debug.WriteLine("Rpicked : " + Bag.Rpicked);
            Debug.WriteLine("Rprice : " + Bag.Rprice);
            Debug.WriteLine("age : " + Bag.age);


            using (var db=new KioskDbcontext())
            {
                for(int i = 0; i < pickedDB.Length; i++)
                {
                    bagdb.NO = i.ToString();
                    bagdb.picked = pickedDB[i].ToString();
                    bagdb.price = priceDB[i].ToString();
                    bagdb.Age = Bag.age;
                    db.bagdbs.Add(bagdb);

                    db.SaveChanges();
                }
               
            }

            return Json("");
        }
        [HttpPost]
        public ActionResult ageinput(int age)
        {
            Bag.age += age;

            return Json(Lcount);
        }


        public string Change(string name)
        {
            string ret = "";
            if (name == "싸이버거")
                ret = "cyburger";
            else if (name == "화이트 갈릭 버거")
                ret = "whitegarlic";
            else if (name == "휠렛버거")
                ret = "whillet";
            else if (name == "언빌리버블버거")
                ret = "unbeliev";
            else if (name == "인크레더블버거")
                ret = "incredible";
            else if (name == "치즈베이컨버거")
                ret = "cheesebacon";
            else if (name == "치킨 커틀렛 버거")
                ret = "chickcutlet";
            else if (name == "통새우버거")
                ret = "shrimp";
            else if (name == "할라피뇨통가슴살버거")
                ret = "hallaga";
            else if (name == "할라피뇨통살버거")
                ret = "hallasal";
            else if (name == "햄치즈휠렛버거")
                ret = "hamcheese";
            else if (name == "디럭스 불고기 버거")
                ret = "buldelux";
            else if (name == "딥 치즈 버거")
                ret = "deepcheese";
            else if (name == "리샐버거")
                ret = "resell";
            else if (name == "마살라 버거")
                ret = "masalla";
            else if (name == "불갈비 치킨 버거")
                ret = "galbichic";
            else if (name == "불고기 버거")
                ret = "bulgogi";
            else if (name == "불싸이 버거")
                ret = "hotcybur";
            else if (name == "스파이시 디럭스 불고기 버거")
                ret = "spicydeluxbulgogi";
            else if (name == "스파이시 불고기 버거")
                ret = "spicybulgogi";

            return ret;
        }

        //public ActionResult BestThree()
        //{

        //    using (var db = new KioskDbcontext())
        //    {
        //        bagsDB bagdb = new bagsDB();
        //        var bestList = from user in db.bagdbs.GroupBy(user => user.picked)
        //                       select new
        //                       {
        //                           count = user.Count(),


        //                       };
                              

        //    }



        //    return Json("success");

        //}

        //위의 itemOut작업을 모든 것에 적용해본것, 만약 2개 이상일 경우 싸그리 지워지게
    }
}