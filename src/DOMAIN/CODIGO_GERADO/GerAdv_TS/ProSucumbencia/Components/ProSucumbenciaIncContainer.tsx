'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ProSucumbenciaInc from '../Crud/Inc/ProSucumbencia';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ProSucumbenciaIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ProSucumbenciaIncContainer: React.FC<ProSucumbenciaIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ProSucumbenciaInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ProSucumbenciaIncContainer;