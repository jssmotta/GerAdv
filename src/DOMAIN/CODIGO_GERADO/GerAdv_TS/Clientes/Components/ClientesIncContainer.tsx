'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ClientesInc from '../Crud/Inc/Clientes';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ClientesIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ClientesIncContainer: React.FC<ClientesIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ClientesInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ClientesIncContainer;