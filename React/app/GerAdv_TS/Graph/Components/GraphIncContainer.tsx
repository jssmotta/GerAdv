'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GraphInc from '../Crud/Inc/Graph';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GraphIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GraphIncContainer: React.FC<GraphIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GraphInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GraphIncContainer;