//
//  TwoViewController.swift
//  ProjetTransversaux
//
//  Created by Supinfo on 08/03/16.
//  Copyright © 2016 Ingesup. All rights reserved.
//

import UIKit

class TwoViewController: UIViewController {

    var Username = String()
    var Password = String()
    @IBOutlet weak var lblMessage: UILabel!
    @IBOutlet weak var lblPassword: UILabel!
    
    override func viewDidLoad() {
        super.viewDidLoad()
        lblMessage.text = Username
        lblPassword.text = Password
        // Do any additional setup after loading the view.
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
