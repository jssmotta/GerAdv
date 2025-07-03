import React from 'react';
import { render } from '@testing-library/react';
import AlertasEnviadosIncContainer from '@/app/GerAdv_TS/AlertasEnviados/Components/AlertasEnviadosIncContainer';
// AlertasEnviadosIncContainer.test.tsx
// Mock do AlertasEnviadosInc
jest.mock('@/app/GerAdv_TS/AlertasEnviados/Crud/Inc/AlertasEnviados', () => (props: any) => (
<div data-testid='alertasenviados-inc-mock' {...props} />
));
describe('AlertasEnviadosIncContainer', () => {
  it('deve renderizar AlertasEnviadosInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AlertasEnviadosIncContainer id={id} navigator={mockNavigator} />
  );
  const alertasenviadosInc = getByTestId('alertasenviados-inc-mock');
  expect(alertasenviadosInc).toBeInTheDocument();
  expect(alertasenviadosInc.getAttribute('id')).toBe(id.toString());

});
});