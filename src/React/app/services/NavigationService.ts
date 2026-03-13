import { AppRouterInstance } from 'next/dist/shared/lib/app-router-context.shared-runtime';
import { INavigator } from '../interfaces/INavigator';

export class NextNavigationService implements INavigator {
  private router: AppRouterInstance;

  constructor(router: AppRouterInstance) {
    this.router = router;
  }

  navigateTo(path: string): void {
    this.router.push(path);
  }
}
