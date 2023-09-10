import './App.css';
import { Link } from 'react-router-dom';



function Home() {
  return (
    <div>
      <br/>
      <Link to='/teacher/read'>
                <button className='view-button'>View Teachers</button>
            </Link>
            &nbsp; &nbsp; &nbsp; &nbsp;
            <Link to='/student/read'>
            <button className='view-button'>View Students</button>
            </Link>     
    </div>
  );
}

export default Home;
