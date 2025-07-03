// AgendaRepetirDiasGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AgendaRepetirDiasGridAdapter } from '@/app/GerAdv_TS/AgendaRepetirDias/Adapter/AgendaRepetirDiasGridAdapter';
// Mock AgendaRepetirDiasGrid component
jest.mock('@/app/GerAdv_TS/AgendaRepetirDias/Crud/Grids/AgendaRepetirDiasGrid', () => () => <div data-testid='agendarepetirdias-grid-mock' />);
describe('AgendaRepetirDiasGridAdapter', () => {
  it('should render AgendaRepetirDiasGrid component', () => {
    const adapter = new AgendaRepetirDiasGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('agendarepetirdias-grid-mock')).toBeInTheDocument();
  });
});