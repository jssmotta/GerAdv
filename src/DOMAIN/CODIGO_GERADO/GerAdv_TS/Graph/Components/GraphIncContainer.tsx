'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GraphInc from '../Crud/Inc/Graph';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GraphIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GraphIncContainer: React.FC<GraphIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GraphInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GraphIncContainer;