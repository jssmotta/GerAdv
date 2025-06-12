'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import TipoModeloDocumentoInc from '../Crud/Inc/TipoModeloDocumento';
import { getParamFromUrl } from '@/app/tools/helpers';
interface TipoModeloDocumentoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const TipoModeloDocumentoIncContainer: React.FC<TipoModeloDocumentoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <TipoModeloDocumentoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default TipoModeloDocumentoIncContainer;