'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EMPClassRiscosInc from '../Crud/Inc/EMPClassRiscos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EMPClassRiscosIncContainerProps {
  id: number;
  navigator: INavigator;
  onSuccess: (registro?: any) => void;
}
const EMPClassRiscosIncContainer: React.FC<EMPClassRiscosIncContainerProps> = ({ id, navigator, onSuccess }) => {
  const handleClose = () => {};
  const handleError = () => {};
  return (
  <EMPClassRiscosInc
  id={id}
  onClose={handleClose}
  onSuccess={onSuccess}
  onError={handleError}
  />
);
};
export default EMPClassRiscosIncContainer;