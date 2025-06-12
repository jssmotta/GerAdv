'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import HorasTrabInc from '../Crud/Inc/HorasTrab';
import { getParamFromUrl } from '@/app/tools/helpers';
interface HorasTrabIncContainerProps {
  id: number;
  navigator: INavigator;
}
const HorasTrabIncContainer: React.FC<HorasTrabIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <HorasTrabInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default HorasTrabIncContainer;