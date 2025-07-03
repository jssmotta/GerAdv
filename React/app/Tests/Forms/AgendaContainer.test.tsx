import React from 'react';
import { render } from '@testing-library/react';
import AgendaIncContainer from '@/app/GerAdv_TS/Agenda/Components/AgendaIncContainer';
// AgendaIncContainer.test.tsx
// Mock do AgendaInc
jest.mock('@/app/GerAdv_TS/Agenda/Crud/Inc/Agenda', () => (props: any) => (
<div data-testid='agenda-inc-mock' {...props} />
));
describe('AgendaIncContainer', () => {
  it('deve renderizar AgendaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <AgendaIncContainer id={id} navigator={mockNavigator} />
  );
  const agendaInc = getByTestId('agenda-inc-mock');
  expect(agendaInc).toBeInTheDocument();
  expect(agendaInc.getAttribute('id')).toBe(id.toString());

});
});