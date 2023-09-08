import './App.css';
import Create from './components/teacher/create';
import CreateStudent  from './components/student/createStudent';
import Read from './components/teacher/read';
import ViewStudents from './components/student/viewStudents';
import Home from './Home';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom'


function App() {
  return (
    <Router>
    <div className='main'>
      <div>
      <h3>Peabux Assessment</h3>
      </div>
      <br/>
      <Routes>
      <Route exact path='/' element={<Home />} />
          <Route path='/teacher/create' element={<Create />} />
          <Route path='/teacher/read' element={<Read />}  />
          <Route path='/student/create' element={<CreateStudent />} />
          <Route path='/student/read' element={<ViewStudents />}  />
      </Routes>

      
    </div>
    </Router>
  );
}

export default App;
