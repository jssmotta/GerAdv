'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import HonorariosDadosContratoInc from '../Crud/Inc/HonorariosDadosContrato';
import { getParamFromUrl } from '@/app/tools/helpers';
interface HonorariosDadosContratoIncContainerProps {
  id: number;
  navigator: INavigator;
}
const HonorariosDadosContratoIncContainer: React.FC<HonorariosDadosContratoIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <HonorariosDadosContratoInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default HonorariosDadosContratoIncContainer;