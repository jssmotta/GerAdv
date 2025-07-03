import React from 'react';
import { render } from '@testing-library/react';
import OperadorGruposAgendaIncContainer from '@/app/GerAdv_TS/OperadorGruposAgenda/Components/OperadorGruposAgendaIncContainer';
// OperadorGruposAgendaIncContainer.test.tsx
// Mock do OperadorGruposAgendaInc
jest.mock('@/app/GerAdv_TS/OperadorGruposAgenda/Crud/Inc/OperadorGruposAgenda', () => (props: any) => (
<div data-testid='operadorgruposagenda-inc-mock' {...props} />
));
describe('OperadorGruposAgendaIncContainer', () => {
  it('deve renderizar OperadorGruposAgendaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <OperadorGruposAgendaIncContainer id={id} navigator={mockNavigator} />
  );
  const operadorgruposagendaInc = getByTestId('operadorgruposagenda-inc-mock');
  expect(operadorgruposagendaInc).toBeInTheDocument();
  expect(operadorgruposagendaInc.getAttribute('id')).toBe(id.toString());

});
});