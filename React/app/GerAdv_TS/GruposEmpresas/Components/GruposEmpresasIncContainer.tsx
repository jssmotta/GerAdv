'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GruposEmpresasInc from '../Crud/Inc/GruposEmpresas';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GruposEmpresasIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GruposEmpresasIncContainer: React.FC<GruposEmpresasIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GruposEmpresasInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GruposEmpresasIncContainer;