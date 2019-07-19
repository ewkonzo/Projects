using System;
using System.IO.Ports;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Diagnostics;
using System.Net.Mail;

namespace Server
{
    static class Messages
    {
        public static string TranType = "";

        public enum enMessageType//request:response
        {
            mtUnknown = -1,
            mtRequestMiniStatement,//1100:1110
            mtRequestCheckBalance,//1100:1110
            mtRequestCashWithdrawalCoop,//1200:1210
            mtRequestCashWithdrawalVisa,//1100:1110
            mtRequestReversal,//1420:1430
            mtRequestPOS,//1100:1110
            mtRequestMPesaWD,//1200:1210
            mtRequestAirtimeTopup,//1200:1210
            mtUtilityPayment,//1200:2010
            mtSupermarket,//1200:1210
            mtPOSSchoolPayment,//00*
            mtPOSPurchaseWithCashBack,//09*
            mtPOSCashWithdrawal,//01*
            mtPOSCashDeposit,//21*
            mtPOSBenefitCashWithdrawal,//15*
            mtPOSCashDepositToCard,//21*
            mtPOSMBanking,
            mtPOSBalanceEnquiry,
            mtPOSMiniStatement
        }

        public static string MTIDRequestMiniStatement
        {
            get
            {
                return "1100";
            }
        }

        public static string MTIDRequestCheckBalance
        {
            get
            {
                return "02881100";
            }
        }

        public static string MTIDRequestReversal
        {
            get
            {
                return "04061420";
            }
        }

        public static string MTIDRequestPOS
        {
            get
            {
                return "1100";
            }
        }

        public static string MTIDRequestMPesaWD
        {
            get
            {
                return "1200";
            }
        }

        public static string MTIDRequestAirtimeTopup
        {
            get
            {
                return "1200";
            }
        }

        public static string MTIDResponseMiniStatement
        {
            get
            {
                return "1110";
            }
        }

        public static string MTIDResponseCheckBalance
        {
            get
            {
                return "1110";
            }
        }

        public static string MTIDResponseCashWithdrawalCoop
        {
            get
            {
                return "1210";
            }
        }

        public static string MTIDResponseCashWithdrawalVisa
        {
            get
            {
                return "1110";
            }
        }

        public static string MTIDResponseReversalRequest
        {
            get
            {
                return "1430";
            }
        }

        public static string MTIDResponsePOS
        {
            get
            {
                return "1110";
            }
        }

        public static string MTIDResponseMPesaWD
        {
            get
            {
                return "1210";
            }
        }

        public static string MTIDResponseAirtimeTopup
        {
            get
            {
                return "1210";
            }
        }

        //public static string MTIDResponsePOSSchoolPayment
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSPurchaseWithCashBack
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSCashDeposit
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSBenefitCashWithdrawal
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSCashDepositCard
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSMBanking
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSCashWithdrawal
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSBalanceEnquiry
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        //public static string MTIDResponsePOSMiniStatement
        //{
        //    get
        //    {
        //        return "1210";
        //    }
        //}

        public static enMessageType MessageType(string procCode,
            string field41, string field42, string field94
            )
        {
            enMessageType mt = enMessageType.mtUnknown;

            try
            {

                switch (procCode)
                {
                    case "00"://normal purchase,school payment,utility payments
                        {
                            if (field94.Contains("40401PISO"))
                            {
                                if (!field41.Contains("40401PISO"))
                                    mt = enMessageType.mtRequestPOS;
                            }
                            else if (
                                field94.Contains("RTPSID9900") &&
                                field42.Contains("SCH")
                                )
                                mt = enMessageType.mtPOSSchoolPayment;

                            //else
                            //    mt = enMessageType.mtUtilityPayment;

                            break;
                        }
                    case "01"://cash withdrawal
                        {
                            if (field94.Contains("40401PISO"))
                                mt = enMessageType.mtPOSCashWithdrawal;

                            break;
                        }
                    case "09"://purchase with cashback
                        {
                            if (field94.Contains("40401PISO"))
                                mt = enMessageType.mtPOSPurchaseWithCashBack;

                            break;
                        }
                    case "21"://cash deposit
                        {
                            if (field94.Contains("40401PISO"))
                                mt = enMessageType.mtPOSCashDeposit;
                            else if (
                                field94.Contains("RTPSID9900") &&
                                field42.Contains("0002P001")
                                )
                                mt = enMessageType.mtPOSCashDepositToCard;
                            else if (field41.Contains("MPOS"))
                                mt = enMessageType.mtPOSMBanking;
                            break;
                        }
                    case "15"://benefit cash withdrawal
                        {
                            if (field94.Contains("40401PISO"))
                                mt = enMessageType.mtPOSBenefitCashWithdrawal;

                            break;
                        }
                    case "31"://pos - balance enquiry
                        {
                            if (field41.Contains("POS") && field94.Contains("40401PISO"))
                                mt = enMessageType.mtPOSBalanceEnquiry;

                            break;
                        }
                    case "37"://pos - mini statement
                        {
                            if (field41.Contains("POS") && field94.Contains("40401PISO"))
                                mt = enMessageType.mtPOSMiniStatement;

                            break;
                        }
                }
                //switch (MTI)
                //{
                //    case "1100":// balance enquiry - 1100
                //        {

                //            break;
                //        }//end here
                //}
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
            return mt;
        }

        /// <summary>
        /// for other types of transactions except POS types
        /// </summary>
        /// <param name="MTI"></param>
        /// <param name="procCode"></param>
        /// <returns></returns>
        public static enMessageType MessageType(string MTI, string procCode,
            string field41, string field42, string field94)
        {
            enMessageType mt = enMessageType.mtUnknown;

            try
            {
                switch (MTI)
                {
                    case "1100":// balance enquiry - 1100
                        {
                            switch (procCode)
                            {
                                case "30"://bal enquiry
                                    {
                                        mt = enMessageType.mtRequestCheckBalance;
                                        break;
                                    }
                                case "31"://bal enquiry
                                    {
                                        mt = enMessageType.mtRequestCheckBalance;
                                        break;
                                    }
                                case "01"://cash w/d - visa
                                    {
                                        mt = enMessageType.mtRequestCashWithdrawalVisa;
                                        break;
                                    }
                                case "00"://P.O.S
                                    {
                                        mt = enMessageType.mtRequestPOS;
                                        break;
                                    }
                                default://mini statement
                                    {
                                        mt = enMessageType.mtRequestMiniStatement;
                                        break;
                                    }
                            }

                            break;
                        }
                    case "1110":// balance enquiry - 1100
                        {
                            switch (procCode)
                            {
                                case "30"://bal enquiry
                                    {
                                        mt = enMessageType.mtRequestCheckBalance;
                                        break;
                                    }
                                case "31"://bal enquiry
                                    {
                                        mt = enMessageType.mtRequestCheckBalance;
                                        break;
                                    }
                                case "01"://cash w/d - visa
                                    {
                                        mt = enMessageType.mtRequestCashWithdrawalVisa;
                                        break;
                                    }
                                case "00"://P.O.S
                                    {
                                        mt = enMessageType.mtRequestPOS;
                                        break;
                                    }
                                default://mini statement
                                    {
                                        mt = enMessageType.mtRequestMiniStatement;
                                        break;
                                    }
                            }

                            break;
                        }
                    case "1101":// balance enquiry - 1100
                        {
                            mt = enMessageType.mtRequestCheckBalance;
                            break;
                        }
                    case "1200":// cash w/d - coop or m-pesa w/d or utility payment
                        {
                            if (procCode == "01" || procCode == "56")//cash w/d - coop
                                mt = enMessageType.mtRequestCashWithdrawalCoop;
                            else if (procCode == "00")//m-pesa w/d or airtime topup or utility payment
                            {
                                if (field41.Contains("ATM") && field94.Contains("RTPSID"))
                                    mt = enMessageType.mtUtilityPayment;//mt = Utility Payment;
                                else
                                    mt = enMessageType.mtRequestMPesaWD;//mt = enMessageType.mtRequestAirtimeTopup;
                            }
                            break;
                        }
                    case "1111":// balance enquiry - 1100
                        {
                            mt = enMessageType.mtRequestCheckBalance;
                            break;
                        }
                    case "1210":// cash w/d - coop or m-pesa w/d
                        {
                            if (procCode == "01" || procCode == "56")//cash w/d - coop
                                mt = enMessageType.mtRequestCashWithdrawalCoop;
                            else if (procCode == "00")//m-pesa w/d or airtime topup or utility payment
                            {
                                if (field41.Contains("ATM") && field94.Contains("RTPSID"))
                                    mt = enMessageType.mtUtilityPayment;//mt = Utility Payment;
                                else
                                    mt = enMessageType.mtRequestMPesaWD;//mt = enMessageType.mtRequestAirtimeTopup;
                            }
                            break;
                        }
                    case "1420":// reversal
                        {
                            mt = enMessageType.mtRequestReversal;
                            break;
                        }
                    case "1421":// reversal
                        {
                            mt = enMessageType.mtRequestReversal;
                            break;
                        }
                    case "0000":// reversal
                        {
                            mt = enMessageType.mtRequestReversal;
                            break;
                        }
                    case "1430":// reversal
                        {
                            mt = enMessageType.mtRequestReversal;
                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }
            return mt;
        }

        public static int MessageTypeNumber(string MTI, string procCode)
        {
            int i = -1;

            try
            {
                switch (MTI)
                {
                    case "1100":// balance enquiry - 1100
                        {
                            if (procCode == "30" || procCode == "31")//bal enquiry
                                i = 1;
                            else if (procCode == "01")//cash w/d - visa (or P.O.S)
                                i = 2;
                            else//mini statement
                                i = 0;

                            break;
                        }
                    case "1101":// balance enquiry - 1100
                        {
                            i = 1;

                            break;
                        }
                    case "1200":// cash w/d - coop or mpesa w/d or airtime topup
                        {
                            i = 2;

                            break;
                        }
                    case "1420":// reversal
                        {
                            i = 3;

                            break;
                        }
                    case "1421":// reversal
                        {
                            i = 3;

                            break;
                        }
                }
            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }

            return i;
        }

        /// <summary>
        /// Cardholder-originated transactions include:
        /// purchase, withdrawal, deposit, refund, reversal,
        /// balance inquiry, payments and inter-account transfers
        /// </summary>
        public static string RequestDescription(enMessageType messageType)
        {
            string s = "";

            try
            {
                switch (messageType)
                {
                    case enMessageType.mtRequestMiniStatement: { s = "Mini-Statements "; break; }
                    case enMessageType.mtRequestCheckBalance: { s = "Balance Inquiry "; break; }
                    case enMessageType.mtRequestCashWithdrawalCoop: { s = "Cash Withdrawal - Coop Bank ATM "; break; }
                    case enMessageType.mtRequestCashWithdrawalVisa: { s = "Cash Withdrawal - Visa ATM "; break; }
                    case enMessageType.mtRequestReversal: { s = "Reversal "; break; }
                    case enMessageType.mtRequestPOS: { s = "Point-Of-Sale "; break; }
                    case enMessageType.mtRequestMPesaWD: { s = "MPesa Withdrawal "; break; }
                    case enMessageType.mtRequestAirtimeTopup: { s = "Airtime Topup "; break; }
                    case enMessageType.mtUtilityPayment: { s = "Utility Payment "; break; }
                    case enMessageType.mtPOSSchoolPayment: { s = "POS - School Payment "; break; }
                    case enMessageType.mtPOSPurchaseWithCashBack: { s = "POS - Purchase With Cash Back "; break; }
                    case enMessageType.mtPOSCashDeposit: { s = "POS - Cash Deposit "; break; }
                    case enMessageType.mtPOSBenefitCashWithdrawal: { s = "POS - Benefit Cash Withdrawal "; break; }
                    case enMessageType.mtPOSCashDepositToCard: { s = "POS - Cash Deposit to Card "; break; }
                    case enMessageType.mtPOSMBanking: { s = "POS - M Banking "; break; }
                    case enMessageType.mtPOSCashWithdrawal: { s = "POS - Cash Withdrawal "; break; }
                    case enMessageType.mtPOSBalanceEnquiry: { s = "POS - Balance Enquiry "; break; }
                    case enMessageType.mtPOSMiniStatement: { s = "POS - Mini Statement "; break; }
                }

            }
            catch (Exception ex)
            {
                Logs.ReportError(ex);
            }

            return s;
        }

        /// <summary>
        /// Cardholder-originated transactions include:
        /// purchase, withdrawal, deposit, refund, reversal,
        /// balance inquiry, payments and inter-account transfers
        /// </summary>
        public static string SampleRequest
        {
            get
            {
                string s = "";

                string tt = "";
                int i;

                //allow user to specify the transaction type
                Console.WriteLine("Select transaction type:");
                i = Convert.ToInt32(Console.ReadLine());

                //i = new Random(DateTime.Now.Millisecond).Next(15);

                switch (i)
                {
                    case 0: { tt = "Mini-Statements Request"; break; }
                    case 1: { tt = "Balance Inquiry Request"; break; }
                    case 2: { tt = "Cash Withdrawal Request - Coop Bank ATM"; break; }
                    case 3: { tt = "Cash Withdrawal Request - Visa ATM"; break; }
                    case 4: { tt = "Reversal Request"; break; }
                    case 5: { tt = "Point-Of-Sale Request"; break; }
                    case 6: { tt = "MPesa Withdrawal Request"; break; }
                    case 7: { tt = "Airtime Topup Request"; break; }
                    case 8: { tt = "Utility Request"; break; }
                    case 9: { tt = "Supermarket Request"; break; }
                    case 10: { tt = "POS - School Payment Request"; break; }
                    case 11: { tt = "POS - Purchase With Cash Back Request"; break; }
                    case 12: { tt = "POS - Cash Deposit Request"; break; }
                    case 13: { tt = "POS - Benefit Cash Withdrawal Request"; break; }
                    case 14: { tt = "POS - Cash Deposit to Card Request"; break; }
                    case 15: { tt = "POS - M Banking Request"; break; }
                    default: { tt = "Mini-Statements Request"; break; }
                }

                TranType = tt;

                //Console.WriteLine("Transaction Type: {0}", tt);

                switch (i)
                {
                    case 0://MINI STATEMENT - FROM ANY ATM
                        {

                            s = "02821100E0340541AEE100000000000C1000000016429933029456730337000037691809091109203109102111019131461086011084407820006RTPSID374299330831056091=09101211934045000000925409376918230690000ATM0179 00520179       40kakamegasacco001>NAIROBI              KE009AT01O222 05SACCO10RTPSID966605SACCO";

                            break;
                        }
                    case 1://BALANCE ENQUIRY - FROM ANY ATM
                        {
                            s = "02881100E0340541AEE1A0000000000C1000000016429933029456730331000012841910093018561511095111019131461086011084407820006RTPSID374299330294567303=11091211563917000000027318128419127892000ATM0346 00180346       40chuka002>CHUKA                        KE009AT01O222 KESKES05SACCO10RTPSID966605SACCO";

                            break;
                        }
                    case 2://CASH WITHDRAWAL - FROM COOP BANK ATM
                        {
                            s = "03951200F674055BAEE1E0000000000E12000000164299336500038336010000000002000000000002000000101708375161000000261086111017103751121051110191314620060111110170001420110817115459084407820006RTPSID374299336500038336=12101211350125800000129010261086791451000ATM0094 00650094       40Agakhanbr006>NAIROBI                  KE009AT01O222 KESKESKES05SACCO10RTPSID966615RNB00945026108605SACCO18015000000065080065";
                            //s = "03951200F674055BAEE1E0000000000E12000000164299336500038336010000000002000000000002000000101708375161000000261086111017103751121051110191314620060111110170001420110817115459084407820006RTPSID374299336500038336=12101211350125800000129010261086791451000ATM0094 00650094       40Agakhanbr006>NAIROBI                  KE009AT01O222 KESKESKES05SACCO10RTPSID966615RNB00945026108605SACCO18015000000065080065";
                            //s = "03811200F67405D9AEE1E0000000000E12000000164299332765686216010000000000500000000000500000101315314261000000011032111013170810111151010191314420015066010110924000084407820006RTPSID364299332765686216D1111121122244060000228613170810342297000POS00699POSAG000310    40BRENTWRICH AGENCIES>NAIROBI           KE009PT01O222 KESKESKES05SACCO0940401PISO15RNB00944801103205SACCO18011992759057030035";
                            //s = "03951200F674055BAEE1E0000000000E12000000164299330294567303010000000000650000000000650000090605383961000000820769110906073839120851110191314620060111109060001420100105131109084407820006RTPSID374299330294567303=12081211992450800000124907820769146125000ATM0256 00680256       40NANYUKIBR002>NANYUKI                  KE009AT01O222 KESKESKES05SACCO10RTPSID966615RNB00941982076905SACCO18015000000068040068";
                            //s = "03951200F674055BAEE1E0000000000E12000000164299330294567303010000000001000000000001000000082508210561000000644656110825102105130451110191314620060111108250001420061128153133084407820006RTPSID374299330294567303=13041211571404500000123710644656903264000ATM0085 00100085       40nyeribr002>NYERI                      KE009AT01O222 KESKESKES05SACCO10RTPSID966615RNB00941064465605SACCO18015000000010040010";
                            //s = "03951200F674055BAEE1E0000000000E12000000164299330294567303010000000001000000000001000000041318105961000000281113110413181059121151110191314620060111104130001420080625122540084407820006RTPSID374299330294567303=12111211933920800000110318281113479447000ATM0149 00300149       40Mtwapa001>MOMBASA                     KE009AT01O222 KESKESKES05SACCO10RTPSID966615RNB00934328111305SACCO18015000000030030030";
                            //s = "03951200F674055BAEE1E0000000000E12000000164299330294567303010000000000070000000000700000110113565261000000313584101101135652110551110191314620060111011010001420061128153134084407820006RTPSID374299330294567303=11051211970992300000030513313584375736000ATM0071 00180071       40chuka002>CHUKA                        KE009AT01O222 KESKESKES05SACCO10RTPSID966615RNB00927631358405SACCO18015000000018040018";

                            break;
                        }
                    case 3://CASH WITHDRAWAL - FROM VISA ATM
                        {
                            s = "03311100F4740541AEE1A0000000000E1000000016429933029456730301000000000020000000000000010061000000051930091009212536100421110191500C10060110642448606RTPSID374299330584201373=10041211284593200000928221051930370265000PPT0113 1210113        40PPT OILIBYA SABA SABA MSA>NAIROBI     KE009AF01O222 KESKES05SACCO10RTPSVISDIF11155398495  05SACCO";

                            break;
                        }
                    case 4://REVERSAL - FROM ANY ATM
                        {
                            s = "03671420F47405DB8EE1E1000000000C12000000164299330294567303010000000001000000000001000000610000006446561108251021051304511101913146400402160111108250001420061128153133084407820006RTPSID123710644656903264400ATM0085 00100085       40nyeribr002>NYERI                      KE009AT01O222 KESKESKES321200644656110825102105084407820005SACCO10RTPSID966605SACCO18015000000010040010";
                            //s = "03671421F47405DB8EE1E1000000000C12000000164299336500032073010000000000100000000000100000610000003348331108241806441302511101913146400402160111108240001420061128152740084407820006RTPSID123618334833151290400ATM0042 00330042       40athiriver001>NAIROBI                  KE009AT01O222 KESKESKES321200334833110824180644084407820005SACCO10RTPSID966605SACCO18015000000033030033";
                            //s = "03671421F47405DB8EE1E1000000000C12000000164299330294567303010000000000200000000000200000610000000858141009301738001105511101913146400402160111009290001420081021095605084407820006RTPSID027317085814777766400ATM0175 00550175       40nkubu001>NAIROBI                      KE009AT01O222 KESKESKES321200085814100930173800084407820005SACCO10RTPSID966605SACCO";

                            break;
                        }
                    case 5://POINT OF SALE - SAME AS CASH W/D FROM VISA ATM
                        {
                            s = "03311100F4740541AEE1A0000000000E1000000016429933029456730300000000000005900000000005900061000000027778090911091300101220010195400110054110644075506RTPSID374299330294567303=101212113911038000009254090277785296430002300001714059017       40UCHUMI MOMBASA ROAD>NAIROBI           KE009PF01O222 KESKES05SACCO10RTPSVISDIF11149410547  05SACCO";

                            break;
                        }
                    case 6://MPESA WITHDRAWAL
                        {
                            s = "03771200F67405598EE1E0000000000E530000001642993302945673030000000000000100000000000100000129155701610000000861781001291557011012100S011041102005999100119000084407820006RTPSID002915086178475880000MPMOBILE1000014        40MPESA MOBILE BANKING>NAIROBI          KE009NT01O222 KESKESKES05SACCO10RTPSID990011178086178  MPESAMBANKING,0722218305 05SACCO18012400000097970097013MPESAMBANKING";

                            break;
                        }
                    case 7://AIRTIME TOPUP
                        {
                            s = "03721200F67405598EE1E0000000000E530000001642993302945673030000000000000100000000000100000129160215610000000881671001291602151012100S301041102005999100119000084407820006RTPSID002916088167553614000MOBILE  1000002        40MBANKING>NAIROBI                      KE009NT01O222 KESKESKES05SACCO10RTPSID990011178088167  MBANKING,4234567890      05SACCO18018900000097090097008MBANKING";

                            break;
                        }
                    case 8://UTILITY PAYMENT
                        {
                            s = "04111200F6740559AEE1E0000000000E530000001642993302945673030000000000000100000000000100000810105323610000000369951108101053231203511S019131462004900100119000084407820006RTPSID374299330294567303=12031211340634700000122210036995125735000ATM0346 00351001       40ATM0346>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO10RTPSID990015RNB009401036995209359401                05SACCO18012400690198000035004KPLC";
                            //s = "04111200F6740559AEE1E0000000000E530000001642993302945673030000000000000500000000000500000415160602610000000694251104151606021304511S019131462004900100119000084407820006RTPSID374299330294567303=13041211372590800000110516069425900180000ATM0001 00351001       40ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO10RTPSID990015RNB009344069425245059801                05SACCO18012400690198000035004KPLC";
                            //s = "04071200F6740559AEE1E0000000000E530000001642993302945673030000000000000001000000000001000914140004610000008720151009141400041106511S019131462004900100119000084407820006RTPSID374299330294567303=11061211613013600000025714872015640295000ATM0001 00351001       40ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO10RTPSID990011256872015  KPLC, 226155004          05SACCO18012400690198000035004KPLC";

                            break;
                        }
                    case 9://SUPER-MARKET
                        {
                            s = "03311100F4740541AEE1A0000000000E1000000016429933029456730300000000000002300000000002300061000000334762100914143457110620010195400110054110645474006RTPSID374299330294567303=11061211613013600000025714334762309402000000009027235690        40NAKUMATT MEGA>NAIROBI                 KE009PF01O222 KESKES05SACCO0940401PISO11256953177  05SACCO";

                            break;
                        }
                    case 10://POS - School Payment
                        {
                            s = "04071100F6740559AEE1E0000000000E530000001642993302945673030000000000000001000000000001000914140004610000008720151009141400041106511S019131462004900100119000084407820006RTPSID374299330294567303=11061211613013600000025714872015640295000ATM0001 SCHU0000000000040ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO10RTPSID990011256872015  KPLC, 226155004          05SACCO18012400690198000035004KPLC";

                            break;
                        }
                    case 11://POS - Purchase With Cash Back
                        {
                            s = "04071100F6740559AEE1E0000000000E530000001642993302945673030900000000000001000000000001000914140004610000008720151009141400041106511S019131462004900100119000084407820006RTPSID374299330294567303=11061211613013600000025714872015640295000ATM0001 00351001       40ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO0940401PISO11256872015  KPLC, 226155004          05SACCO18012400690198000035004KPLC";

                            break;
                        }
                    case 12://POS - Benefit Cash Withdrawal
                        {
                            s = "04071100F6740559AEE1E0000000000E530000001642993302945673031500000000000001000000000001000914140004610000008720151009141400041106511S019131462004900100119000084407820006RTPSID374299330294567303=11061211613013600000025714872015640295000ATM0001 00351001       40ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO0940401PISO11256872015  KPLC, 226155004          05SACCO18012400690198000035004KPLC";

                            break;
                        }
                    case 13://POS - Cash Deposit to Card
                        {
                            s = "04071100F6740559AEE1E0000000000E530000001642993302945673032100000000000001000000000001000914140004610000008720151009141400041106511S019131462004900100119000084407820006RTPSID374299330294567303=11061211613013600000025714872015640295000ATM0001 0002P001000000040ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO10RTPSID990011256872015  KPLC, 226155004          05SACCO18012400690198000035004KPLC";
                            //s = "03501421F47405D98EE1E1000000000C1200000016429933029456730321000000000002000000000002000061000000713996110513123337130451010191314440040216010110513000084407820006RTPSID213313123337614863400POS00159POSSA000020 40NTIMINYAKIRU SACCO>MERU KE009PT01O222 KESKESKES321200713996110513123337084407820005SACCO0940401PISO05SACCO18011990215484010005";
                            break;
                        }
                    case 14://POS - M Banking
                        {
                            s = "04071100F6740559AEE1E0000000000E530000001642993302945673032100000000000001000000000001000914140004610000008720151009141400041106511S019131462004900100119000084407820006RTPSID374299330294567303=11061211613013600000025714872015640295000MPOS000000351001       40ATM0001>KENYA POWER & LIGHTING LTD    KE009PT01O222 KESKESKES05SACCO10RTPSID990011256872015  KPLC, 226155004          05SACCO18012400690198000035004KPLC";

                            break;
                        }
                    case 15://POS - Cash Withdrawal
                        {
                            s = "03311100F4740541AEE1A0000000000E1000000016429933029456730301000000000002300000000002300061000000334762100914143457110620010195400110054110645474006RTPSID374299330294567303=11061211613013600000025714334762309402000000009027235690        40NAKUMATT MEGA>NAIROBI                 KE009PF01O222 KESKES05SACCO0940401PISO11256953177  05SACCO";
                            s = "03811200F67405D9AEE1E0000000000E12000000164299333200454665010000000000050000000000050000072314020761000000086133120723160458140651010191314420015066010120723000084407820006RTPSID364299333200454665D1406121109627670000220523160458138760000POS01680POSAG001259    40WEST END PETROLEUM LTD- KIB>NAIROBI   KE009PT01O222 KESKESKES05SACCO0940401PISO15RNB00966508613305SACCO18011994023665000070";
                            break;
                        }
                    case 16://POS - Cash Deposit
                        {
                            s = "03501421F47405D98EE1E1000000000C1200000016429933029456730321000000000002000000000002000061000000713996110513123337130451010191314440040216010110513000084407820006RTPSID213313123337614863400POS00159POSSA000020    40NTIMINYAKIRU SACCO>MERU               KE009PT01O222 KESKESKES321200713996110513123337084407820005SACCO0940401PISO05SACCO18011990215484010005";
                            break;
                        }
                    case 17://POS - Bal Enquiry
                        {
                            s = "02911100E03405C1AEE1A0000000000C10000000164299330294567303310000731399110407152050120151010191314410815106010084407820006RTPSID374299330294567303D12011211429946400000209707152050537044000POS03   POSBRANCH02    40TEST POS>NAIROBI                      KE009PT01O222 KESKES05SACCO0940401PISO05SACCO";

                            break;
                        }
                    case 18://POS - Mini Statement
                        {
                            s = "02851100E03405C1AEE100000000000C10000000164299336300063450370000585154110408132132120651010191314410815086010084407820006RTPSID374299336300063450D12061211700720000000209808132132268208000POS00066POSSA000010    40WANANCHI SACCO>NYERI                  KE009PT01O222 05SACCO0940401PISO05SACCO";

                            break;
                        }
                    default://MINI STATEMENT - FROM ANY ATM
                        {
                            s = "02851100E03405C1AEE100000000000C10000000164299330294567303370000731402110407154334120151010191314410815086010084407820006RTPSID374299330294567303D12011211429946400000209707154334887978000POS03   POSBRANCH02    40TEST POS>NAIROBI                      KE009PT01O222 05SACCO0940401PISO05SACCO";

                            break;
                        }
                }
                return s.ToUpper();
            }
        }

    }
}
