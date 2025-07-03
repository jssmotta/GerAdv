// ContatoCRMGridAdapter.test.tsx
import React from 'react';
import { render } from '@testing-library/react';
import { ContatoCRMGridAdapter } from '@/app/GerAdv_TS/ContatoCRM/Adapter/ContatoCRMGridAdapter';
// Mock ContatoCRMGrid component
jest.mock('@/app/GerAdv_TS/ContatoCRM/Crud/Grids/ContatoCRMGrid', () => () => <div data-testid='contatocrm-grid-mock' />);
describe('ContatoCRMGridAdapter', () => {
  it('should render ContatoCRMGrid component', () => {
    const adapter = new ContatoCRMGridAdapter();
    const { getByTestId } = render(<>{adapter.render()}</>);
    expect(getByTestId('contatocrm-grid-mock')).toBeInTheDocument();
  });
});