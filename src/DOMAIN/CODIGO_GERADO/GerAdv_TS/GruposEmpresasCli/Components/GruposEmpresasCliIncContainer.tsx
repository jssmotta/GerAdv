'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import GruposEmpresasCliInc from '../Crud/Inc/GruposEmpresasCli';
import { getParamFromUrl } from '@/app/tools/helpers';
interface GruposEmpresasCliIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const GruposEmpresasCliIncContainer: React.FC<GruposEmpresasCliIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <GruposEmpresasCliInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default GruposEmpresasCliIncContainer;