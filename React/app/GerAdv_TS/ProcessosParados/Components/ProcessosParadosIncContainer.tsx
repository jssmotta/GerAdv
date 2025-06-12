'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProcessosParadosInc from '../Crud/Inc/ProcessosParados';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProcessosParadosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const ProcessosParadosIncContainer: React.FC<ProcessosParadosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <ProcessosParadosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default ProcessosParadosIncContainer;