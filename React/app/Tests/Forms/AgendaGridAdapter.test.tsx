// AgendaGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AgendaGridAdapter } from '@/app/GerAdv_TS/Agenda/Adapter/AgendaGridAdapter';
// Mock AgendaGrid component
jest.mock('@/app/GerAdv_TS/Agenda/Crud/Grids/AgendaGrid', () => () => <div data-testid='agenda-grid-mock' />);
describe('AgendaGridAdapter', () => {
  it('should render AgendaGrid component', () => {
    const adapter = new AgendaGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('agenda-grid-mock')).toBeInTheDocument();
  });
});