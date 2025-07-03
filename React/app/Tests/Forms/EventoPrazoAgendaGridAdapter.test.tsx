// EventoPrazoAgendaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { EventoPrazoAgendaGridAdapter } from '@/app/GerAdv_TS/EventoPrazoAgenda/Adapter/EventoPrazoAgendaGridAdapter';
// Mock EventoPrazoAgendaGrid component
jest.mock('@/app/GerAdv_TS/EventoPrazoAgenda/Crud/Grids/EventoPrazoAgendaGrid', () => () => <div data-testid='eventoprazoagenda-grid-mock' />);
describe('EventoPrazoAgendaGridAdapter', () => {
  it('should render EventoPrazoAgendaGrid component', () => {
    const adapter = new EventoPrazoAgendaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('eventoprazoagenda-grid-mock')).toBeInTheDocument();
  });
});