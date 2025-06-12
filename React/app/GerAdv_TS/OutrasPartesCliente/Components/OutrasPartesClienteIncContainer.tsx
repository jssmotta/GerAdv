'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OutrasPartesClienteInc from '../Crud/Inc/OutrasPartesCliente';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OutrasPartesClienteIncContainerProps {
  id: number;
  navigator: INavigator;
}
const OutrasPartesClienteIncContainer: React.FC<OutrasPartesClienteIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <OutrasPartesClienteInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default OutrasPartesClienteIncContainer;