import React from 'react';
import { render } from '@testing-library/react';
import AlertasIncContainer from '@/app/GerAdv_TS/Alertas/Components/AlertasIncContainer';
// AlertasIncContainer.test.tsx
// Mock do AlertasInc
jest.mock('@/app/GerAdv_TS/Alertas/Crud/Inc/Alertas', () => (props: any) => (
<div data-testid='alertas-inc-mock' {...props} />
));
describe('AlertasIncContainer', () => {
  it('deve renderizar AlertasInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AlertasIncContainer id={id} navigator={mockNavigator} />
  );
  const alertasInc = getByTestId('alertas-inc-mock');
  expect(alertasInc).toBeInTheDocument();
  expect(alertasInc.getAttribute('id')).toBe(id.toString());

});
});