'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessosInc from '../Crud/Inc/Processos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProcessosIncContainer: React.FC<ProcessosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProcessosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProcessosIncContainer;