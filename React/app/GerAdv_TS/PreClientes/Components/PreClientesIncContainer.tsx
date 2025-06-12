'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import PreClientesInc from '../Crud/Inc/PreClientes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface PreClientesIncContainerProps {
  id: number;
  navigator: INavigator;
}
const PreClientesIncContainer: React.FC<PreClientesIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <PreClientesInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default PreClientesIncContainer;