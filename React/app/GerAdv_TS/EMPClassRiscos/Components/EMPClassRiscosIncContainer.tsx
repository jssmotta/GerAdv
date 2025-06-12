'use client';
import { INavigator } from '@/app/interfaces/INavigator';
import EMPClassRiscosInc from '../Crud/Inc/EMPClassRiscos';
import { getParamFromUrl } from '@/app/tools/helpers';
interface EMPClassRiscosIncContainerProps {
  id: number;
  navigator: INavigator;
}
const EMPClassRiscosIncContainer: React.FC<EMPClassRiscosIncContainerProps> = ({ id, navigator }) => {
  const handleClose = () => {};
  const handleSuccess = () => {};
  const handleError = () => {};
  return (
  <EMPClassRiscosInc
  id={id}
  onClose={handleClose}
  onSuccess={handleSuccess}
  onError={handleError}
  />
);
};
export default EMPClassRiscosIncContainer;