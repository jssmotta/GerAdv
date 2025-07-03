// AgendaRepetirGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AgendaRepetirGridAdapter } from '@/app/GerAdv_TS/AgendaRepetir/Adapter/AgendaRepetirGridAdapter';
// Mock AgendaRepetirGrid component
jest.mock('@/app/GerAdv_TS/AgendaRepetir/Crud/Grids/AgendaRepetirGrid', () => () => <div data-testid='agendarepetir-grid-mock' />);
describe('AgendaRepetirGridAdapter', () => {
  it('should render AgendaRepetirGrid component', () => {
    const adapter = new AgendaRepetirGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('agendarepetir-grid-mock')).toBeInTheDocument();
  });
});