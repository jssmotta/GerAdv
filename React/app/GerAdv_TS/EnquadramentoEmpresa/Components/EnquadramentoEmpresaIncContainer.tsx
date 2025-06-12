'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EnquadramentoEmpresaInc from '../Crud/Inc/EnquadramentoEmpresa';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EnquadramentoEmpresaIncContainerProps {
  id: number;
  navigator: INavigator;
}
const EnquadramentoEmpresaIncContainer: React.FC<EnquadramentoEmpresaIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <EnquadramentoEmpresaInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default EnquadramentoEmpresaIncContainer;