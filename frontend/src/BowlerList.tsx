import { useEffect, useState } from "react";
import {Bowler} from "./types/Bowler"


function BowlerList () {

    const [bowlers, setBowlers] = useState <Bowler[]>([]);

    useEffect(() => {
        const fetchBowler = async () =>{
        const response = await fetch('https://localhost:5000/api/Bowlers');
        const data = await response.json();
        setBowlers(data);
    };
    fetchBowler();
    
    },[]);

    

    return (
        <>
        <h2>Bowlers</h2>
        <table>
            <thead>
                <tr>
                    <th>Bowler Name</th>
                    <th>Team Name</th>
                    <th>Address</th>
                    <th>City</th>
                    <th>State</th>
                    <th>Zip</th>
                    <th>Phone Number</th>
                </tr>
            </thead>
            <tbody>
                {
                    bowlers.map((b)=> (
                        <tr key={b.id}>
                            <td>{b.bowlerName}</td>
                            <td>{b.teamName}</td>
                            <td>{b.address}</td>
                            <td>{b.city}</td>
                            <td>{b.state}</td>
                            <td>{b.zip}</td>
                            <td>{b.phoneNumber}</td>

                        </tr>
                    ))
                }

            </tbody>
        </table>
        </>

    );
}

export default BowlerList;