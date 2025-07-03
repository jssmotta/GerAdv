'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import HorasTrabInc from '../Crud/Inc/HorasTrab';
import { getParamFromUrl } from '@/app/tools/helpers';
interface HorasTrabIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const HorasTrabIncContainer: React.FC<HorasTrabIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <HorasTrabInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default HorasTrabIncContainer;