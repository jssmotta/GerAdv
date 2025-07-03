import React from 'react';
import { render } from '@testing-library/react';
import EventoPrazoAgendaIncContainer from '@/app/GerAdv_TS/EventoPrazoAgenda/Components/EventoPrazoAgendaIncContainer';
// EventoPrazoAgendaIncContainer.test.tsx
// Mock do EventoPrazoAgendaInc
jest.mock('@/app/GerAdv_TS/EventoPrazoAgenda/Crud/Inc/EventoPrazoAgenda', () => (props: any) => (
<div data-testid='eventoprazoagenda-inc-mock' {...props} />
));
describe('EventoPrazoAgendaIncContainer', () => {
  it('deve renderizar EventoPrazoAgendaInc com as props corretas', () => {
    const mockNavigator = {} as any;
    const id = 123;
    const { getByTestId } = render(
    <EventoPrazoAgendaIncContainer id={id} navigator={mockNavigator} />
  );
  const eventoprazoagendaInc = getByTestId('eventoprazoagenda-inc-mock');
  expect(eventoprazoagendaInc).toBeInTheDocument();
  expect(eventoprazoagendaInc.getAttribute('id')).toBe(id.toString());

});
});