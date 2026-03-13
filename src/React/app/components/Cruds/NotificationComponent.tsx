import { Notification } from '@progress/kendo-react-notification';

import { INotificationService } from '../../services/notification.service';
interface NotificationComponentProps {
  notificationService: INotificationService;
}

export const NotificationComponent: React.FC<NotificationComponentProps> = ({
  notificationService,
}) => {
  const notificationState = notificationService.getNotificationState();

  if (!notificationState.visible) return null;

  return (
    <Notification
      type={{ style: notificationState.type, icon: true }}
      closable={true}
      onClose={() => notificationService.hideNotification()}
    >
      <span>{notificationState.message}</span>
    </Notification>
  );
};
