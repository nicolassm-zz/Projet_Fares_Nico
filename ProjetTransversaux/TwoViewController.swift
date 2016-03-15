//
//  TwoViewController.swift
//  ProjetTransversaux
//
//  Created by Supinfo on 08/03/16.
//  Copyright © 2016 Ingesup. All rights reserved.
//

import UIKit
import TwitterKit

class TwoViewController: UIViewController {
    
    @IBOutlet weak var imgUser: UIImageView!
    @IBOutlet weak var timelineView: UITableView!
    @IBOutlet weak var lblUser: UILabel!
    var userTweet = TWTRUser()
    
    @IBOutlet weak var lblScreenName: UILabel!
    override func viewDidLoad() {
        let Session = Twitter.sharedInstance().sessionStore.session()
        let client = TWTRAPIClient(userID: Session!.userID)
        client.loadUserWithID(Session!.userID) { (user, error) -> Void in
            self.userTweet = user!
            self.headerLoad()
          
            
            
        }
        
        // Do any additional setup after loading the view.
    }

    func headerLoad(){
        self.lblUser.text = self.userTweet.name
        self.lblScreenName.text = "@" + self.userTweet.screenName
        let url = NSURL(string :self.userTweet.profileImageLargeURL)
        if let data = NSData(contentsOfURL: url!){
            self.imgUser.image = UIImage(data: data)
            
        }

    }
    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
    }
    

    /*
    // MARK: - Navigation

    // In a storyboard-based application, you will often want to do a little preparation before navigation
    override func prepareForSegue(segue: UIStoryboardSegue, sender: AnyObject?) {
        // Get the new view controller using segue.destinationViewController.
        // Pass the selected object to the new view controller.
    }
    */

}
