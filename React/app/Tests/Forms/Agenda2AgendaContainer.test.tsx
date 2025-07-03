import React from 'react';
import { render } from '@testing-library/react';
import Agenda2AgendaIncContainer from '@/app/GerAdv_TS/Agenda2Agenda/Components/Agenda2AgendaIncContainer';
// Agenda2AgendaIncContainer.test.tsx
// Mock do Agenda2AgendaInc
jest.mock('@/app/GerAdv_TS/Agenda2Agenda/Crud/Inc/Agenda2Agenda', () => (props: any) => (
<div data-testid='agenda2agenda-inc-mock' {...props} />
));
describe('Agenda2AgendaIncContainer', () => {
  it('deve renderizar Agenda2AgendaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <Agenda2AgendaIncContainer id={id} navigator={mockNavigator} />
  );
  const agenda2agendaInc = getByTestId('agenda2agenda-inc-mock');
  expect(agenda2agendaInc).toBeInTheDocument();
  expect(agenda2agendaInc.getAttribute('id')).toBe(id.toString());

});
});