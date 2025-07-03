import React from 'react';
import { render } from '@testing-library/react';
import StatusInstanciaIncContainer from '@/app/GerAdv_TS/StatusInstancia/Components/StatusInstanciaIncContainer';
// StatusInstanciaIncContainer.test.tsx
// Mock do StatusInstanciaInc
jest.mock('@/app/GerAdv_TS/StatusInstancia/Crud/Inc/StatusInstancia', () => (props: any) => (
<div data-testid='statusinstancia-inc-mock' {...props} />
));
describe('StatusInstanciaIncContainer', () => {
  it('deve renderizar StatusInstanciaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <StatusInstanciaIncContainer id={id} navigator={mockNavigator} />
  );
  const statusinstanciaInc = getByTestId('statusinstancia-inc-mock');
  expect(statusinstanciaInc).toBeInTheDocument();
  expect(statusinstanciaInc.getAttribute('id')).toBe(id.toString());

});
});