'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import HonorariosDadosContratoInc from '../Crud/Inc/HonorariosDadosContrato';
import { getParamFromUrl } from '@/app/tools/helpers';
interface HonorariosDadosContratoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const HonorariosDadosContratoIncContainer: React.FC<HonorariosDadosContratoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <HonorariosDadosContratoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default HonorariosDadosContratoIncContainer;