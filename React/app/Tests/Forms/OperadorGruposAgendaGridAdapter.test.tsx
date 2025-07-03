// OperadorGruposAgendaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { OperadorGruposAgendaGridAdapter } from '@/app/GerAdv_TS/OperadorGruposAgenda/Adapter/OperadorGruposAgendaGridAdapter';
// Mock OperadorGruposAgendaGrid component
jest.mock('@/app/GerAdv_TS/OperadorGruposAgenda/Crud/Grids/OperadorGruposAgendaGrid', () => () => <div data-testid='operadorgruposagenda-grid-mock' />);
describe('OperadorGruposAgendaGridAdapter', () => {
  it('should render OperadorGruposAgendaGrid component', () => {
    const adapter = new OperadorGruposAgendaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('operadorgruposagenda-grid-mock')).toBeInTheDocument();
  });
});