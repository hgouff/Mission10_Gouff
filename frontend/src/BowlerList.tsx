
// Import necessary hooks from React
import { useEffect, useState } from "react";
import {Bowler} from "./types/Bowler"

// Functional component for displaying the list of bowlers
function BowlerList () {

    const [bowlers, setBowlers] = useState <Bowler[]>([]);

    // useEffect hook runs when the component mounts
    useEffect(() => {
        const fetchBowler = async () =>{
        const response = await fetch('https://localhost:5000/api/Bowlers'); // Fetches data from the backend API
        const data = await response.json();
        setBowlers(data);
    };
    fetchBowler(); // Calls the function to fetch data
    
    },[]);

    
// Renders the table with bowler data
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