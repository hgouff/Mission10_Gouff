
//Hannah Gouff

import './App.css' // Imports the main stylesheet for the app
import BowlerList from './BowlerList' //Imports the bowler list

function Welcome(){
  return <h1>Bowling League: Marlins & Sharks</h1>
}

function App() {
  
//displays Welcome and Bowler list on the page
  return (
    <>
      <Welcome />
      <BowlerList />
    </>
  )
}

// Exports the App component as the default export

export default App
