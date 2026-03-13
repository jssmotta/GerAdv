{
  `/* Versão 1.2.0 26-05-2025 */`;
}

export interface INotificationService {
  notify(entity: INotifySystemEntity): void;
}

export class NotificationService implements INotificationService {
  notify(entity: INotifySystemEntity): void {
    NotifySystem(entity);
  }
}

export enum NotifySystemActions {
  ADD = 0,
  UPDATE = 1,
  DELETE = 2,
  INFO = 3,
  ERROR = 4,
}

export interface INotifySystemEntity {
  entity: string;
  id: number;
  action: NotifySystemActions;
  message?: string;
}

// Ensure BroadcastChannel exists in test environments (Jest/Node)
const ChannelClass: any = (typeof (global as any).BroadcastChannel !== 'undefined') ? (global as any).BroadcastChannel : (typeof BroadcastChannel !== 'undefined' ? BroadcastChannel : null);

const channel: any = ChannelClass ? new ChannelClass('notify-system') : {
  postMessage: (_: any) => {},
  onmessage: null,
};

channel.onmessage = (event: any) => {
  const entity = event.data as INotifySystemEntity;
  if (subscriptions[entity.entity]) {
    subscriptions[entity.entity].forEach((callback) => callback(entity));
  }
  if (subscriptions['*']) {
    subscriptions['*'].forEach((callback) => callback(entity));
    Object.keys(subscriptions).forEach((key) => {
      if (key !== '*') {
        subscriptions[key].forEach((callback) => callback(entity));
      }
    });
  }
};

type NotifyCallback = (entity: INotifySystemEntity) => void;

const subscriptions: { [entityName: string]: NotifyCallback[] } = {};

export const NotifySystem = (entity: INotifySystemEntity) => {
  if (subscriptions[entity.entity]) {
    subscriptions[entity.entity].forEach((callback) => callback(entity));
  }

  if (subscriptions['*']) {
    subscriptions['*'].forEach((callback) => callback(entity));
  }
  channel.postMessage(entity);
};

export const subscribeToNotifications = (
  entityName: string,
  callback: NotifyCallback
) => {
  if (!subscriptions[entityName]) {
    subscriptions[entityName] = [];
  }
  subscriptions[entityName].push(callback);

  return () => {
    subscriptions[entityName] = subscriptions[entityName].filter(
      (cb) => cb !== callback
    );
    if (subscriptions[entityName].length === 0) {
      delete subscriptions[entityName];
    }
  };
};

/*
    useEffect(() => {
        // Subscribe to notifications for a specific entity
        const unsubscribe = subscribeToNotifications("myEntity", (entity) => {
            console.log("Received notification:", entity);
            // Handle the notification here
        });

        // Clean up the subscription when the component unmounts
        return () => {
            unsubscribe();
        };
    }, []);

*/
