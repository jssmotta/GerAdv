// AgendaRecordsGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { AgendaRecordsGridAdapter } from '@/app/GerAdv_TS/AgendaRecords/Adapter/AgendaRecordsGridAdapter';
// Mock AgendaRecordsGrid component
jest.mock('@/app/GerAdv_TS/AgendaRecords/Crud/Grids/AgendaRecordsGrid', () => () => <div data-testid='agendarecords-grid-mock' />);
describe('AgendaRecordsGridAdapter', () => {
  it('should render AgendaRecordsGrid component', () => {
    const adapter = new AgendaRecordsGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('agendarecords-grid-mock')).toBeInTheDocument();
  });
});