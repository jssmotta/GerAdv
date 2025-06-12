import { IGridComponent } from '@/app/interfaces/IGridComponent';
interface GridContainerProps {
  grid: IGridComponent;
}
const PosicaoOutrasPartesGridContainer: React.FC<GridContainerProps> = ({ grid }) => (
<div className='grid-container'>
  {grid.render()}
</div>
);
export default PosicaoOutrasPartesGridContainer;