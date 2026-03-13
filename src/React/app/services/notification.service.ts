import {
  INotificationState,
  NotificationType,
} from '../types/notification.types';

export interface INotificationService {
  showNotification: (message: string, type: NotificationType) => void;
  hideNotification: () => void;
  getNotificationState: () => INotificationState;
}

export class NotificationService implements INotificationService {
  private state: INotificationState = {
    visible: false,
    message: '',
    type: 'info',
  };

  showNotification(message: string, type: NotificationType = 'info'): void {
    this.state = { visible: true, message, type };
  }

  hideNotification(): void {
    this.state = { visible: false, message: '', type: 'info' };
  }

  getNotificationState(): INotificationState {
    return this.state;
  }
}
