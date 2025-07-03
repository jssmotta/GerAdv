'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoModeloDocumentoInc from '../Crud/Inc/TipoModeloDocumento';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoModeloDocumentoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const TipoModeloDocumentoIncContainer: React.FC<TipoModeloDocumentoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <TipoModeloDocumentoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default TipoModeloDocumentoIncContainer;