namespace ConsoleApp6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true) // 인벤토리 메뉴 루프
            {
                Console.Clear();
                Console.WriteLine("1.상태보기");
                Console.WriteLine("2.인벤토리");
                Console.WriteLine("3.상점");
                Console.Write("원하는 메뉴를 선택하세요: ");

                string input = Console.ReadLine(); //사용자 정보 읽어오기

                StatusInfo playerStatus = new StatusInfo();
                playerStatus.status(); //상태 창 정보 초기화

                InventoryInfo playerInventory = new InventoryInfo();
                playerInventory.inventory(); //인벤토리 정보 초기화

                ShopInfo playershop = new ShopInfo();
                playershop.shop(); // 샵 정보 초기화

                if (input == "1") // 입력이 "1"이면 상태 출력
                {
                    Console.Clear();
                    Console.WriteLine("\n[플레이어 정보]"); // 상태 창
                    Console.WriteLine();
                    Console.WriteLine($"직업   | {playerStatus.job}");
                    Console.WriteLine($"레벨   | {playerStatus.level}");
                    Console.WriteLine($"공격력 | {playerStatus.attack}");
                    Console.WriteLine($"방어력 | {playerStatus.defensive}");
                    Console.WriteLine($"골드   | {playerStatus.gold}");
                }
                else if (input == "2")
                {
                    bool inventoryMenu = true;
                    while (inventoryMenu) // 인벤토리 메뉴 루프
                    {
                        Console.Clear();
                        Console.WriteLine("\n[인벤토리]"); // 인벤토리를 창
                        Console.WriteLine();
                        Console.WriteLine($"[1] 무쇠갑옷    | {playerInventory.armor} 개 | 방어력 + {playerInventory.plateArmor}     | {(playerInventory.isArmorEquipped ? "[E] 해제" : "[e] 장착")}");
                        Console.WriteLine($"[2] 스파르타 창 | {playerInventory.weapon} 개 | 공격력 + {playerInventory.spearSta}     | {(playerInventory.isWeaponEquipped ? "[E] 해제" : "[e] 장착")}");
                        Console.WriteLine($"[3] HP 포션     | {playerInventory.potion} 개 | 체력회복 + {playerInventory.item_1} | {(playerInventory.isPotionEquipped ? "[E] 해제" : "[e] 장착")}");

                        Console.Write("\n장착/해제할 아이템 번호를 입력하세요 (0: 메뉴로 돌아가기): ");
                        string itemInput = Console.ReadLine();

                        if (itemInput == "1")
                        {
                            playerInventory.isArmorEquipped = !playerInventory.isArmorEquipped;
                            Console.WriteLine(playerInventory.isArmorEquipped ? "무쇠갑옷을 장착했습니다." : "무쇠갑옷을 해제했습니다.");
                            Console.WriteLine("\n아무 키를 누르면 계속합니다...");
                            Console.ReadKey();
                        }
                        else if (itemInput == "2")
                        {
                            playerInventory.isWeaponEquipped = !playerInventory.isWeaponEquipped;
                            Console.WriteLine(playerInventory.isWeaponEquipped ? "스파르타 창을 장착했습니다." : "스파르타 창을 해제했습니다.");
                            Console.WriteLine("\n아무 키를 누르면 계속합니다...");
                            Console.ReadKey();
                        }
                        else if (itemInput == "3")
                        {
                            playerInventory.isPotionEquipped = !playerInventory.isPotionEquipped;
                            Console.WriteLine(playerInventory.isPotionEquipped ? "포션을 장착했습니다." : "포션 장착을 해제했습니다.");
                            Console.WriteLine("\n아무 키를 누르면 계속합니다...");
                            Console.ReadKey();
                        }
                        else if (itemInput == "0") // "0"을 입력하면 인벤토리 메뉴를 종료
                        {
                            inventoryMenu = false;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("잘못된 입력입니다.");
                            Console.WriteLine("\n아무 키를 누르면 계속합니다...");
                            Console.ReadKey();
                        }
                    }
                }

                else if (input == "3")
                {
                    Console.WriteLine("\n[스파르타 상점]");
                    Console.WriteLine();
                    Console.WriteLine($"수련자 갑옷     | {playershop.noviceArmor} | 방어력 + {playershop.staNovice}  | 수련에 도움을 주는 갑옷입니다.");
                    Console.WriteLine($"무쇠 갑옷       | {playershop.ironArmor} | 방어력 + {playershop.staIron}  | 무쇠로 만들어져 튼튼한 갑옷입니다.");
                    Console.WriteLine($"스파르타의 갑옷 | {playershop.spartaArmor} | 방어력 + {playershop.staSArmor} | 스파르타의 전사들이 사용했다는 전설의 갑옷입니다.");
                    Console.WriteLine($"낡은 검         | {playershop.oldSword} | 공격력 + {playershop.staOSword}  | 쉽게 볼 수 있는 낡은 검입니다.");
                    Console.WriteLine($"청동 도끼       | {playershop.bronzeAx} | 공격력 + {playershop.staBAex}  | 어디선가 사용됐던 것 같은 도끼입니다.");
                    Console.WriteLine($"스파르타의 창   | {playershop.spartaSpear} | 공격력 + {playershop.staSSpear}  | 스파르타의 전사들이 사용했다는 절설의 창입니다.");
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");

                }
            }
        }



        public class StatusInfo()
        {
            public int level;
            public string job;
            public int attack;
            public int defensive;
            public string gold;

            public void status()
                //스테이터스
            {
                this.level = 1;
                this.job = "전사";
                this.attack = 10;
                this.defensive = 5;
                this.gold = "1500 G";
            }
        }

        public class InventoryInfo()
        {
            //인벤토리
            public int armor;
            public int weapon;
            public int potion;

            public int spearSta;
            public int plateArmor;
            public int item_1;

            // 장착 상태를 나타내는 변수 추가
            public bool isArmorEquipped;
            public bool isWeaponEquipped;
            public bool isPotionEquipped;

            public void inventory()
            {
                //장비 개수
                this.armor = 1;
                this.weapon = 1;
                this.potion = 1;
                
                //장비 능력치
                this.spearSta = 7;
                this.plateArmor = 5;
                this.item_1 = 100;

                // 초기 장착 상태를 false로 설정
                this.isArmorEquipped = false;
                this.isWeaponEquipped = false;
                this.isPotionEquipped = false;
            }
        }

        public class ShopInfo()
        {
            //상점
            public int noviceArmor;
            public int ironArmor;
            public int spartaArmor;
            public int oldSword;
            public int bronzeAx;
            public int spartaSpear;

            public int staNovice;
            public int staIron;
            public int staSArmor;
            public int staOSword;
            public int staBAex;
            public int staSSpear;

            public void shop()
            {
                //상점 품목 개수
                this.noviceArmor = 1;
                this.ironArmor = 1;
                this.spartaArmor = 1;
                this.oldSword = 1;
                this.bronzeAx = 1;
                this.spartaSpear = 1;

                //장비 능력치
                this.staNovice = 5;
                this.staIron = 9;
                this.staSArmor = 15;
                this.staOSword = 2;
                this.staBAex = 5;
                this.staSSpear = 7;
            }
        }
    }
}
