// AgendaStatusGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AgendaStatusGridAdapter } from '@/app/GerAdv_TS/AgendaStatus/Adapter/AgendaStatusGridAdapter';
// Mock AgendaStatusGrid component
jest.mock('@/app/GerAdv_TS/AgendaStatus/Crud/Grids/AgendaStatusGrid', () => () => <div data-testid='agendastatus-grid-mock' />);
describe('AgendaStatusGridAdapter', () => {
  it('should render AgendaStatusGrid component', () => {
    const adapter = new AgendaStatusGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('agendastatus-grid-mock')).toBeInTheDocument();
  });
});