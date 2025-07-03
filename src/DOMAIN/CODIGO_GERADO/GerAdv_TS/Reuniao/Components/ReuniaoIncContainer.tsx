'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import ReuniaoInc from '../Crud/Inc/Reuniao';
import { getParamFromUrl } from '@/app/tools/helpers';
interface ReuniaoIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const ReuniaoIncContainer: React.FC<ReuniaoIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <ReuniaoInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default ReuniaoIncContainer;