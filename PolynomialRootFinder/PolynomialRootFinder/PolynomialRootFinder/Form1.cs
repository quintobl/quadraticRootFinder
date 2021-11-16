using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PolynomialRootFinder
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }

        double checkNumber;
        double numeratorPlus = 0;
        double numeratorMinus = 0;
        double discriminant = 0;
        double squareRootOfDiscriminant = 0;
        double denominator = 0;
        double rootPlus = 0;
        double rootMinus = 0;

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            txtACoefficient.BackColor = Color.White;
            txtBCoefficient.BackColor = Color.White;
            txtCCoefficient.BackColor = Color.White;

            if (ValidateAllInput() == true)
            {
                CalculateDiscriminant();
                CheckIfDiscriminantIsReal(discriminant);

                if (CheckIfDiscriminantIsReal(discriminant) == false)
                {
                    MessageBox.Show("No real solutions.  Please enter different coefficients.");
                }
                else
                {
                    CalculateSquareRootOfDiscriminant(discriminant);

                    CalculateNumeratorForFirstXValueAddition(squareRootOfDiscriminant);

                    CalculateNumeratorForSecondXValueSubtraction(squareRootOfDiscriminant);

                    CalculateDenominator();

                    CalculateFirstXValue();

                    CalculateSecondXValue();
                }
            }
        }

        public double CalculateDiscriminant()
        {
            discriminant = (double.Parse(txtBCoefficient.Text) * double.Parse(txtBCoefficient.Text))
            - (4 * double.Parse(txtACoefficient.Text) * double.Parse(txtCCoefficient.Text));

            return discriminant;
        }

        public bool CheckIfDiscriminantIsReal(double discriminant)
        {
            if (discriminant < 0)
            {
                txtACoefficient.BackColor = Color.Yellow;
                txtBCoefficient.BackColor = Color.Yellow;
                txtCCoefficient.BackColor = Color.Yellow;
                txtACoefficient.Focus();
                return false;
            }
            else
            {
                return true;
            }
        }

        public double CalculateSquareRootOfDiscriminant(double discriminant)
        {

            squareRootOfDiscriminant = Math.Sqrt(discriminant);

            return squareRootOfDiscriminant;


        }

        public double CalculateNumeratorForFirstXValueAddition(double squareRootOfDiscriminant)
        {
            numeratorPlus = (-1 * double.Parse(txtBCoefficient.Text)) + squareRootOfDiscriminant;
            return numeratorPlus;
        }

        public double CalculateNumeratorForSecondXValueSubtraction(double squareRootOfDiscriminant)
        {
            numeratorMinus = (-1 * double.Parse(txtBCoefficient.Text)) - squareRootOfDiscriminant;
            return numeratorMinus;
        }


        public double CalculateDenominator()
        {
            denominator = 2 * double.Parse(txtACoefficient.Text);
            return denominator;
        }


        public void CalculateFirstXValue()
        {
            rootPlus = (numeratorPlus / denominator);
            txtFirstRoot.Text = rootPlus.ToString();
        }

        public void CalculateSecondXValue()
        {
            rootMinus = (numeratorMinus / denominator);
            txtSecondRoot.Text = rootMinus.ToString();
        }


        public bool ValidateCoefficientA()
        {
            if (double.TryParse(txtACoefficient.Text, out checkNumber) == false)
            {
                txtACoefficient.BackColor = Color.White;

                MessageBox.Show("Please enter a valid number.");
                txtACoefficient.BackColor = Color.Yellow;
                txtACoefficient.Focus();
                return false;
            }
            return true;
        }

        public bool ValidateCoefficientB()
        {
            if (double.TryParse(txtBCoefficient.Text, out checkNumber) == false)
            {
                txtBCoefficient.BackColor = Color.White;

                MessageBox.Show("Please enter a valid number.");
                txtBCoefficient.BackColor = Color.Yellow;
                txtBCoefficient.Focus();
                return false;
            }
            return true;
        }

        public bool ValidateCoefficientC()
        {
            txtCCoefficient.BackColor = Color.White;

            if (double.TryParse(txtCCoefficient.Text, out checkNumber) == false)
            {
                MessageBox.Show("Please enter a valid number.");
                txtCCoefficient.BackColor = Color.Yellow;
                txtCCoefficient.Focus();
                return false;
            }
            return true;
        }


        public bool ValidateAllInput()
        {
            if (ValidateCoefficientA() == true)
            {
                if (ValidateCoefficientB() == true)
                {
                    if (ValidateCoefficientC() == true)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtACoefficient.BackColor = Color.White;
            txtBCoefficient.BackColor = Color.White;
            txtCCoefficient.BackColor = Color.White;
            txtFirstRoot.BackColor = Color.White;
            txtSecondRoot.BackColor = Color.White;

            txtACoefficient.Clear();
            txtBCoefficient.Clear();
            txtCCoefficient.Clear();
            txtFirstRoot.Clear();
            txtSecondRoot.Clear();

            txtACoefficient.Focus();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }


    }
}