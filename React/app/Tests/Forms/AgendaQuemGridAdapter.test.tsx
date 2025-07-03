// AgendaQuemGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AgendaQuemGridAdapter } from '@/app/GerAdv_TS/AgendaQuem/Adapter/AgendaQuemGridAdapter';
// Mock AgendaQuemGrid component
jest.mock('@/app/GerAdv_TS/AgendaQuem/Crud/Grids/AgendaQuemGrid', () => () => <div data-testid='agendaquem-grid-mock' />);
describe('AgendaQuemGridAdapter', () => {
  it('should render AgendaQuemGrid component', () => {
    const adapter = new AgendaQuemGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('agendaquem-grid-mock')).toBeInTheDocument();
  });
});