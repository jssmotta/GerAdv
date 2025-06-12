import { IGridComponent } from '@/app/interfaces/IGridComponent';
interface GridContainerProps {
  grid: IGridComponent;
}
const ClientesSociosGridContainer: React.FC<GridContainerProps> = ({ grid }) => (
<div className='grid-container'>
  {grid.render()}
</div>
);
export default ClientesSociosGridContainer;