//
//  ViewController.swift
//  ProjetTransversaux
//
//  Created by Supinfo on 07/03/16.
//  Copyright © 2016 Ingesup. All rights reserved.
//


import UIKit
import TwitterKit


class ViewController: UIViewController {

    override func viewDidLoad() {
        super.viewDidLoad()
        // Do any additional setup after loading the view, typically from a nib.        
        let logInButton = TWTRLogInButton { (session, error) in
        if let unwrappedSession = session {
            let alert = UIAlertController(title: "Logged In",
                message: "User \(unwrappedSession.userName) has logged in",
                preferredStyle: UIAlertControllerStyle.Alert
            )
            alert.addAction(UIAlertAction(title: "OK", style: UIAlertActionStyle.Default, handler:nil))
            self.ViewChange()
            self.presentViewController(alert, animated: true, completion:nil)
            
            
        } else {
            NSLog("Login error: %@", error!.localizedDescription);
        }
    }
    
    // TODO: Change where the log in button is positioned in your view
    logInButton.center = self.view.center
    self.view.addSubview(logInButton)

    
    }

    override func didReceiveMemoryWarning() {
        super.didReceiveMemoryWarning()
        // Dispose of any resources that can be recreated.
        
    }

    func ViewChange(){
        self.navigationController?.pushViewController(self.storyboard?.instantiateViewControllerWithIdentifier("Timeline") as! TwoViewController
            , animated: true)
    }
    
}

