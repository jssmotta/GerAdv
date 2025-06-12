'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GruposEmpresasInc from '../Crud/Inc/GruposEmpresas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GruposEmpresasIncContainerProps {
  id: number;
  navigator: INavigator;
}
const GruposEmpresasIncContainer: React.FC<GruposEmpresasIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <GruposEmpresasInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default GruposEmpresasIncContainer;