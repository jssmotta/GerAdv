'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import OutrasPartesClienteInc from '../Crud/Inc/OutrasPartesCliente';
import { getParamFromUrl } from '@/app/tools/helpers';
interface OutrasPartesClienteIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const OutrasPartesClienteIncContainer: React.FC<OutrasPartesClienteIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <OutrasPartesClienteInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default OutrasPartesClienteIncContainer;